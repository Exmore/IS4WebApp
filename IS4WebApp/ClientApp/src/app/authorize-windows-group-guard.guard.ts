import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree } from '@angular/router';
import { AuthorizeService } from './api-authorization/authorize.service';
import { QueryParameterNames } from './api-authorization/api-authorization.constants';

@Injectable({
    providedIn: 'root'
})
export class AuthorizeWindowsGroupGuardGuard implements CanActivate {
    constructor(private authorize: AuthorizeService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> |
        Promise<boolean | UrlTree> |
        boolean |
        UrlTree {
        return this.authorize.getUser().pipe(map((u: any) => !!u && !!u.hasUsersGroup)).pipe(tap((isAuthorized: boolean) => this.handleAuthorization(isAuthorized, state)));;
    }

    private handleAuthorization(isAuthenticated: boolean, state: RouterStateSnapshot) {
        if (!isAuthenticated) {
            window.location.href = "/Identity/Account/Login?" + QueryParameterNames.ReturnUrl + "=/";
        }
    }
}
