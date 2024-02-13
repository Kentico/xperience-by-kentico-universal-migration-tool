import { ImportStats } from "../shared/ImportStats";
import { ImportService } from "./import-service";

class MockImportService implements ImportService {
    async upload(file: File) {
        this._result = undefined
        for (var i = 0; i <= 100; i += 1) {
            await new Promise(r => setTimeout(r, 50))
            this.setProgress(i)
        }
        this.setResult({
            SuccessfulImports: { ContentType: 10, Languages: 2 },
            Errors: []
        })
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
    result(): ImportStats | undefined {
        return this._result
    }
    setResult(value: ImportStats) {
        this._result = value
        this.updateObservers()
    }

    private observers: (()=>void)[] = []
    observe(callback: () => void) {
        this.observers.push(callback)
    }
    private updateObservers() {
        for (const observer of this.observers)
            observer()
    }
}

export default MockImportService