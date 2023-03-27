//$33D9D6FB
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

export class ConvTestService {
    public static async NoyuBirArttir(no: number): Promise<number> {
        let url: string = "/api/ConvTestService/NoyuBirArttir";
        let input = { "no": no };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<number>(url, input);
        return result;
    }
}