import { ObjectImportErrorKind } from "../shared/ObjectImportErrorKind";

export interface ImportStats {
    SuccessfulImports: { [ObjectType: string]: number; };
    Errors: { ObjectId: string; ErrorKind: ObjectImportErrorKind; Description: string; }[];
}
