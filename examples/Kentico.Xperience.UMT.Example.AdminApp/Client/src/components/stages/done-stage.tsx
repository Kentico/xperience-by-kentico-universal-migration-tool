import React, { useState } from "react";
import { ActionTile, ActionTileType, Button, ButtonColor, ButtonSize, ButtonType, Callout, CalloutPlacementType, CalloutType, LayoutAlignment, LinkButton, Spacing, Stack, UploadTile, UploadTileSize } from "@kentico/xperience-admin-components";
import { Stage, StageProps } from "./common";
import { ImportStats } from "../../shared/ImportStats";
import { ImportService } from "../../services/import-service";

const content = ({ service, onDone }: StageProps): JSX.Element => {
    const [errorsExpanded, setErrorsExpanded] = useState(false);

    return <div>{service.result() && <><Callout
            type={CalloutType.QuickTip}
            placement={CalloutPlacementType.OnPaper}
            headline="Migration is done"
            subheadline="Info">
            Successful imports:
            <table className="import-log-table">
                {Object.entries(service.result()!.SuccessfulImports).map(([objType, count]) => <tr><td>&#9989; {objType}</td><td>{count}</td></tr>)}
            </table>

            {
                service.result()!.Errors.length != 0 && (
                    <><br />&#9888; There were some problems:<br /> {!errorsExpanded && <LinkButton label="View ..." size={ButtonSize.S} onClick={_ => setErrorsExpanded(true)}></LinkButton>}
                        {errorsExpanded &&
                            <table className="import-log-table">
                                {service.result()!.Errors.map(err => <tr><td>Object &quot;{err.ObjectId}&quot;</td><td>{err.Description}</td></tr>)}
                            </table>
                        }
                    </>
                )
            }
        </Callout>
        <Button className="start-again-button" label="START AGAIN" onClick={onDone}></Button>
    </>}</div>
}

const stage: Stage = {
    content,
    hasBackground: false
}

export default stage