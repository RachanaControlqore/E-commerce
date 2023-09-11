import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../login/Login.service';
import { AddressService } from '../address/address.service';
import { OrderService } from '../order.service';
import { IUserAddress } from '../address/IUserAddress';

@Component({
  selector: 'app-add-to-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.sass']
})
export class CartComponent implements OnInit {

  constructor(private router:Router,private loginService: LoginService,private addressService:AddressService,private orderService:OrderService){

  }
  public username!:string;
  userId!:number;
  public addressDetails:IUserAddress[]=[];

  ngOnInit(): void {
    this.loginService.username$.subscribe((data=>
      {
       this.username=data;
       this.addressService.getUserId(this.username).subscribe((data=>
        {
          this.userId = data.userId;
          this.orderService.getAddress(this.userId).subscribe((data)=>{
            this.addressDetails=data;
          })         
        }))
      }))
  }
  showAddress(){
    this.router.navigate([`./add-user-address`]);
  }
}
