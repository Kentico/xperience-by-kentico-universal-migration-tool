import { ImportStats } from "../shared/ImportStats";

export interface ImportService {
    upload: (file: File) => void,
    observe: (callback: () => void) => void,
    progress: () => number,
    result: () => ImportStats | undefined
}
