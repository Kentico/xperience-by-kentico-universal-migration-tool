import React, { useState } from "react";
import { ActionTile, ActionTileType, Box, Button, ButtonColor, ButtonSize, ButtonType, Callout, CalloutPlacementType, CalloutType, Cols, Column, Divider, DividerOrientation, DropDownActionMenu, FileInput, Headline, HeadlineSize, Input, LayoutAlignment, MenuItem, NotificationBarAlert, ProgressBar, RadioButton, RadioGroup, RadioGroupSize, Row, Select, Shelf, Spacing, Stack, TreeNodeMenuAction, UploadTile, UploadTileSize } from "@kentico/xperience-admin-components";
import { SSE } from "sse.js";
import '../styles/style.css'

export interface ImportSandboxProps {
  children: React.ReactNode
}

export const ImportBackgroundContainer = (props: ImportSandboxProps) => {
    return <div style={{
        backgroundImage: "url(/assets/img/admin/umt-web-admin/background.png)", backgroundSize: 'contain', backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center',
        height: 450,
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
    }} >

        {/*<div className="content-container" style={{*/}
        {/*    display: "grid", justifyContent: 'center',*/}
        {/*    alignItems: 'center', width: "300", height: "300"*/}
        {/*}}>*/}
            {props.children}
        {/*</div>*/}


    </div>
};
