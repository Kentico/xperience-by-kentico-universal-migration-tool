import React, { useEffect, useState } from "react";
import { ActionTile, ActionTileType, Button, ButtonColor, ButtonSize, ButtonType, LayoutAlignment, Spacing, Stack, UploadTile, UploadTileSize } from "@kentico/xperience-admin-components";
import { Stage, StageProps } from "./common";

const content = ({ service, onDone }: StageProps): JSX.Element => {
    const [progress, setProgress] = useState(0)

    useEffect(() => {
        service.observe(() => {
            if (!service.result()) {
                setProgress(service.progress())
            }
            else {
                console.log('inprogress calling ondone')
                setProgress(100)
                onDone()
            }
        })
    }, [])

    return <>
        <svg id="svg-spinner" xmlns="http://www.w3.org/2000/svg" viewBox="-150 -150 300 300" style={{ width: "300", height: "300", gridColumn: 1, gridRow: 1 }}>
            {
                [...Array(13).keys()].map(i =>
                    <circle style={{ animationDelay: `${i * 1}s` }} className='progress-circle' cx={Math.sin(Math.PI * 2 / 12 * i) * 85} cy={Math.cos(Math.PI * 2 / 12 * i) * 85} r={5} fill="rgb(103,56,140)"

                    >
                        <animate attributeName="r" from="5" to="5" begin={`${-i / 13.0 * 1}`} dur='1' values="8;14;8;8" keyTimes="0;0.2;0.4;1" repeatCount='indefinite' />

                    </circle>
                )
            }
        </svg>
        <div
            style={{ gridColumn: 1, gridRow: 1, textAlign: "center", color: "black" }}>
            <span style={{ fontSize: 45 }}>{progress} %</span><br />
            <span style={{ fontSize: 14 }}>Upload progress</span>
        </div>
    </>
}

const stage: Stage = {
    content,
    hasBackground: true
}

export default stage