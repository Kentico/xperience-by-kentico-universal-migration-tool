import { ImportStats } from "../shared/ImportStats";
import { ImportService } from "./import-service";

class BackendImportService implements ImportService {
    private canContinue = true;
    private toofast = false;

    async upload(file: File) {
        const me = this

        this.setProgress(0);
        this.setResult(undefined)

        if (file != null) {
            console.log(file);
            let port = location.port != '' ? `:${location.port}` : '';
            const socket = new WebSocket('ws://' + location.hostname + `${port}/umtsample/ws`);
            socket.binaryType = 'blob';
            socket.onerror = (e) => {
                console.log('error occured', e);
                me.canContinue = false;
                console.log('closing socket => error');
                socket.close();
            }
            socket.onmessage = (event) => {
                var p = JSON.parse(event.data);
                switch (p.type) {
                    case "stats": {
                        try {
                            me.setResult(JSON.parse(p.payload) as ImportStats);
                        }
                        catch (e) {
                            console.error(e);
                        }
                        break;
                    }
                    case "headerConfirmed": {
                        console.log('header confirmed, starting import');
                        me.parseFile(file, (buffer) => {
                            // console.log('chunk');
                            if (socket.readyState == socket.OPEN) {
                                socket.send(buffer);
                                return true;
                            }
                            else {
                                return false;
                            }
                        }, () => {
                            console.log('sending end sequence');
                            var endMessage = Uint8Array.of(0x2D, 0x2D, 0x2D, 0x2D, 0x2D);
                            socket.send(endMessage);

                            setTimeout(() => {
                                // socket.send("---FINISHED---");
                                console.log('closing socket - timeout 60s');
                                socket.close();
                            }, 60000);
                        });
                        break;
                    }
                    case "toofast": {
                        me.toofast = true;
                        break;
                    }
                    case "msg": {
                        break;
                    }
                    case "progress": {
                        const percent = parseInt(p.payload);
                        me.setProgress(percent);
                        break;
                    }
                    case "finished": {
                        console.log('closing socket');
                        me.canContinue = false;
                        if (socket.readyState < socket.CLOSING) {
                            socket.close();
                        }
                        break;
                    }
                }
            };
            socket.onopen = function (event) {
                me.canContinue = true;
                me.setProgress(0);
                document.getElementById("import-content")?.classList.add('hidden')

                socket.send(JSON.stringify({
                    type: 'header',
                    payload: {
                        byteSize: file.size
                    }
                }));
            };
        } else {
            alert('no file selected');
        }
    }

    private parseFile(this: any, file: File, callback: (buffer: ArrayBuffer) => boolean, finishedCallback: () => void) {
        var fileSize = file.size;
        var chunkSize = 32 * 1024; // bytes
        var offset = 0;
        var chunkReaderBlock: null | ((_offset: number, length: number, _file: File) => void) = null;

        const me = this

        var readEventHandler = function (evt: ProgressEvent<FileReader>) {
            if (!me.canContinue) {
                return;
            }

            if (evt.target == null) {
                console.log('progress is null');
                return;
            }
            if (evt.target.error == null && evt.target.result != null) {
                // offset += (evt.target.result as any).length;
                offset += chunkSize;
                if (!callback(evt.target.result as ArrayBuffer)) // callback for handling read chunk
                {
                    return;
                }
            } else {
                finishedCallback();
                console.log("Read error: " + evt.target.error);
                return;
            }
            if (offset >= fileSize) {
                finishedCallback();
                console.log("Done reading file");
                return;
            }

            // of to the next chunk
            if (chunkReaderBlock != null && me.canContinue) {
                // console.log('reading next block');
                chunkReaderBlock(offset, chunkSize, file);
            }
        }

        chunkReaderBlock = function (_offset: number, length: number, _file: File) {
            var r = new FileReader();
            var blob = _file.slice(_offset, length + _offset);
            r.onload = readEventHandler;
            if (me.toofast) {
                setTimeout(() => { r.readAsText(blob); }, 3000);
                console.log('too fast => wait 3s');
                me.toofast = false;
            }
            else {
                r.readAsText(blob);
            }
        }

        // now let's start the read with the first block
        chunkReaderBlock(offset, chunkSize, file);
    }

    private _progress = 0
    private setProgress(value: number) {
        this._progress = value
        this.updateObservers()
    }
    progress() {
        return this._progress
    }

    private _result: ImportStats | undefined
    result(): typeof this._result {
        return this._result
    }
    setResult(value: typeof this._result) {
        this._result = value
        this.updateObservers()
    }

    private observers: Action[] = []
    observe(callback: Action) {
        this.observers.push(callback)
    }
    private updateObservers() {
        for (const observer of this.observers)
            observer()
    }
}

export type Action = () => void

export default BackendImportService