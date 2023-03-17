import { Race } from "src/app/_models/Race";
import { _BaseListResponse, _BaseRequest } from "./_Base";

export class RaceRequest extends _BaseRequest {
  public RaceID: number = 0;
}

export class RaceResponse extends _BaseListResponse<Race> {
}
