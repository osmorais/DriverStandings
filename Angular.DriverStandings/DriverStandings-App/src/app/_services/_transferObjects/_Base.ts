
export class _BaseRequest {
  public Item: any

  constructor(){
  }
}

export class _BaseResponse {
  public Item: any
  public succsess: boolean = false;
  public message: string = '';

  constructor(){
  }
}

export class _BaseListResponse<T> {
    public items: Array<T> = []
    public succsess: boolean = false;
    public message: string = '';

    constructor(){
    }
}
