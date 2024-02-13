import React, { ReactElement, useState } from "react";
import { ActionTile, ActionTileType, Button, ButtonColor, ButtonSize, ButtonType, LayoutAlignment, Spacing, Stack, UploadTile, UploadTileSize } from "@kentico/xperience-admin-components";
import { Stage, StageProps } from "./common";

const content = ({ service, onDone }: StageProps): JSX.Element => {
    const [file, setFile] = useState<File | null>(null)

    return <div id="import-content">{((file === null)
        ?

        <div id='upload'>
            <UploadTile
                acceptFiles=".json"
                firstLineLabel="Drag & Drop .json here"
                secondLineLabel="or"
                buttonLabel="Browse"
                size={UploadTileSize.Full}
                onUpload={([f]) => {
                    if (f instanceof File) {
                        setFile(f);
                    }
                }} />
        </div>

        :
        <Stack align={LayoutAlignment.Center} spacing={Spacing.L}>
            <ActionTile icon='xp-arrow-enter-square' type={ActionTileType.Dashboard} buttonType={ButtonType.Submit} label="IMPORT" onClick={() => {
                service.upload(file!)
                onDone()
            }}/>
            <Button size={ButtonSize.S} color={ButtonColor.Secondary} label="BACK" onClick={_ => setFile(null)} />
        </Stack>
    )}</div>
}

const stage: Stage = { 
    content,
    hasBackground: true
}

export default stage