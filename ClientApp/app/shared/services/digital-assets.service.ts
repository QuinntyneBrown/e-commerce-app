import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class DigitalAssetsService {
    constructor(private _httpClient: HttpClient)
    { }

    public upload(options: { data: FormData }) {
        return this._httpClient.post<{ digitalAssets: Array<any> }>("/api/digitalasset/upload", options.data);        
    }

    public get _baseUrl() { return ""; }
}
