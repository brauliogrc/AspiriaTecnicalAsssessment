export interface IResponse<T> {
    data: T;
    isSuccess: boolean;
    message: string;
    errors: Array<any>; // IEnumerable<ValidationFailure>
}