export interface IResponse<T> {
    data: T;
    isSuccess: boolean;
    message: string;
    errors: Array<IValidationErrors>;
}

interface IValidationErrors {
    propertyName: string;
    errorMessage: string;
}