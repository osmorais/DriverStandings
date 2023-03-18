import { Race } from "src/app/_models/Race";
import { _BaseListResponse, _BaseRequest, _BaseResponse } from "./_Base";

export class RaceRequest extends _BaseRequest {
  public RaceID: number = 0;
}

export class RaceResponse extends _BaseResponse {
}

export class RaceResponseList extends _BaseListResponse<Race> {
}
