
export class _BaseRequest {
}

export class _BaseListResponse<T> {
    public items: Array<T> = []
    public succsess: boolean = false;
    public message: string = '';
}
