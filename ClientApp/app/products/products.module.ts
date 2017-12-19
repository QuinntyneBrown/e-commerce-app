import { NgModule } from '@angular/core';
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { UsersModule } from "../users/users.module";

import { AuthGuardService } from "../shared/guards/auth-guard.service";
import { TenantGuardService } from "../shared/guards/tenant-guard.service";
import { EventHubConnectionGuardService } from "../shared/guards/event-hub-connection-guard.service";
import { CurrentUserGuardService } from "../users/current-user-guard.service";

export const PRODUCT_ROUTES: Routes = [{
    path: 'admin/products',
    component: null,
    canActivate: [
        TenantGuardService,
        AuthGuardService,
        CurrentUserGuardService
    ]
},
{
    path: 'admin/products/create',
    component: null,
    canActivate: [
        TenantGuardService,
        AuthGuardService,
        CurrentUserGuardService
    ]
},
{
    path: 'admin/products/:id',
    component: null,
    canActivate: [
        TenantGuardService,
        AuthGuardService,
        CurrentUserGuardService
    ]
}];

const declarables = [

];

const providers = [];

@NgModule({
    imports: [CommonModule, FormsModule, HttpClientModule, ReactiveFormsModule, RouterModule.forChild(PRODUCT_ROUTES), SharedModule, UsersModule],
    exports: [declarables],
    declarations: [declarables],
    providers: providers
})
export class ProductsModule { }
