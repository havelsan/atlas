//$B072D73D
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PathologyTestProcedure } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";

export class PathologyTestRequestInfoFormViewModel extends BaseViewModel {
  @Type(() => PathologyTestProcedure)
  public _PathologyTestProcedure: PathologyTestProcedure = new PathologyTestProcedure();
  public ProcedureName: string;
  public textDescription: string;
}
