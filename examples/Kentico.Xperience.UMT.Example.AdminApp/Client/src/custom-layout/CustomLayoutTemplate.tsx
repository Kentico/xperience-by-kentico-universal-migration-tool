import React from 'react';
import { useState } from "react";
import { Box, Callout, CalloutPlacementType, CalloutType, Cols, Column, Headline, HeadlineSize, Row, Spacing, Stack } from "@kentico/xperience-admin-components";

import '../styles/style.css'

import { ImportBackgroundContainer } from "../components/import-background-container";
import { TransitionState, transitionClass } from "./transition";
import { Stage, StageId } from "../components/stages/common";

import ImportService from "../services/backend-import-service"

import prepareStage from "../components/stages/prepare-stage"
import inProgressStage from "../components/stages/in-progress-stage"
import doneStage from "../components/stages/done-stage"


// This UI is composed of stages
// To add a new stage, define it in components/stages, add a new StageId, and modify the following dictionaries

const stageFromId = {
    [StageId.Prepare]: prepareStage,
    [StageId.InProgress]: inProgressStage,
    [StageId.Done]: doneStage,
}

const nextStageMap = {
    [StageId.Prepare]: StageId.InProgress,
    [StageId.InProgress]: StageId.Done,
    [StageId.Done]: StageId.Prepare,
}


const importService = new ImportService()
interface CustomLayoutProps {
    readonly label: string;
}

export const CustomLayoutTemplate = ({ label }: CustomLayoutProps) => {
    const [curStageId, setCurStageId] = useState<StageId>(StageId.Prepare);
    const [contentTransition, setContentTransition] = useState<TransitionState>(TransitionState.None);
    const [backgroundTransition, setBackgroundTransition] = useState<TransitionState>(TransitionState.None);
    
    // Fades out current stage, then fades in new stage
    const moveStage = (nextStageId: StageId) => {
        const nextStage = stageFromId[nextStageId]

        setContentTransition(TransitionState.FadeOut)
        if (currentStage.hasBackground != nextStage.hasBackground)
            setBackgroundTransition(TransitionState.FadeOut)

        setTimeout(() => {
            setCurStageId(nextStageId)
            setContentTransition(TransitionState.FadeIn)
            setBackgroundTransition(TransitionState.FadeIn)
        }, 0.5 * 1000)
    }

    const stageContent = (stage: Stage) => <stage.content service={importService} onDone={() => moveStage(nextStageMap[curStageId]) }/>

    const currentStage = stageFromId[curStageId]
    
    return <Box spacing={Spacing.M}>
            <Headline size={HeadlineSize.L} spacingBottom={Spacing.M}>
                {label}
            </Headline>
            <Row spacing={Spacing.XL}>
                <Column
                    cols={Cols.Col12}
                    colsMd={Cols.Col10}
                    colsLg={Cols.Col8}
                    order={Cols.Col2}
                    orderLg={Cols.Col1}
                >
                    <Stack spacing={Spacing.XL} fullHeight={true}>
                        <Callout
                            type={CalloutType.QuickTip}
                            placement={CalloutPlacementType.OnPaper}
                            headline="Basic usage"
                            subheadline="Info"
                        >
                            Component <a target="_blank" href="https://github.com/Kentico/xperience-by-kentico-universal-migration-toolkit/blob/main/docs/README.md">documentation</a> and <a target="_blank" href="https://github.com/Kentico/xperience-by-kentico-universal-migration-toolkit/tree/main/docs/Samples">samples</a>
                        </Callout>

                        <div className={transitionClass(backgroundTransition)}>
                            {currentStage.hasBackground

                                ? <ImportBackgroundContainer>
                                    <div className={`content-container ${transitionClass(contentTransition)}`} style={{
                                        display: "grid", justifyContent: 'center',
                                        alignItems: 'center', width: "300", height: "300"
                                    }}>
                                        {stageContent(currentStage)}
                                    </div>
                                </ImportBackgroundContainer>

                                : <div className={transitionClass(backgroundTransition)}>
                                    {!currentStage.hasBackground && stageContent(currentStage)}
                                </div>
                            }
                        </div>

                    </Stack>
                </Column>
            </Row>
        </Box>;
};
