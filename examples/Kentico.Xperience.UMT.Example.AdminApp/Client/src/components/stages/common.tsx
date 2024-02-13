import { ImportService } from "../../services/import-service"

export enum StageId { Prepare, InProgress, Done }

export interface Stage {
    content: (props: StageProps) => JSX.Element
    hasBackground: boolean
}

export interface StageProps {
    service: ImportService
    onDone: () => void
}
