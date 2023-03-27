
export abstract class IESignatureService {
     abstract getTerminals(): Promise<Array<string>>;
     abstract getCertificates(): Promise<Array<any>>;
     abstract selectCertificateWithSerialNumber(serialNumber: number): Promise<void>;
     abstract login(terminalName: string, pin: string): Promise<void>;
     abstract convertToBase64(content: string): Promise<string>;
     abstract signContent(content: string): Promise<string>;
     abstract showLoginModal(): Promise<void>;
     abstract loginRequired(): Promise<boolean>;

}