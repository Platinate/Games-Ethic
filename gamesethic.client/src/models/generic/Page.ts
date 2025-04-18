interface IPage<T> {
    data: T[];
    index: number;
    size: number;
    totalPages:number;
}

export default IPage;