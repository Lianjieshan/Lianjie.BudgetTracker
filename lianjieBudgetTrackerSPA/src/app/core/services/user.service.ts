import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserCreate } from 'src/app/models/userCreate';
import { UserDetails } from 'src/app/models/userDetails';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService){}

  getAllUsers() : Observable<User[]>{
    return this.apiService.getList("User");
  }

  getUserDetailById(id: number) : Observable<UserDetails>{
    return this.apiService.getOne(`${'User/detail/'}`,id);
  }
  addUser(user: UserCreate){
    return this.apiService.create(`${'User/new'}`, user);
  }
}
