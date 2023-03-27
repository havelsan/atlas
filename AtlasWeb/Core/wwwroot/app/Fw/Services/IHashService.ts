

export abstract class IHashService {
    abstract sha1(object: any): string;
    abstract MD5(object: any): string;
}