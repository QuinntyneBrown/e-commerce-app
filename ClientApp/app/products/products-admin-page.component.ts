import { Component } from "@angular/core";
import { Subject } from "rxjs/Subject";

@Component({
    templateUrl: "./products-admin-page.component.html",
    styleUrls: ["./products-admin-page.component.css"],
    selector: "ce-products-admin-page"
})
export class ProductsAdminPageComponent { 

    private _ngUnsubscribe: Subject<void> = new Subject<void>();

    ngOnDestroy() {
         this._ngUnsubscribe.next();	
    }
}
