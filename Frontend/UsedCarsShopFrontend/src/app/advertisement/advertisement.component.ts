import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DashboardService } from '../services/dashboard.service';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-advertisement',
  templateUrl: './advertisement.component.html',
  styleUrls: ['./advertisement.component.scss']
})
export class AdvertisementComponent implements OnInit{
  userID:any
  temp:any
  card:any
  isWished:boolean = false;

navigateToMessage() {

}
 
  constructor(private route:ActivatedRoute, private dashboardService:DashboardService){

  }
  loadCurrentUserID(){
    let username = localStorage.getItem("Username")
    this.dashboardService.getUserId(username).subscribe(response =>{
      this.userID = response;
      localStorage.setItem("userID", this.userID);
    })
  }
  ngOnInit():void{
      this.loadCard();
      console.log(this.card);
      this.loadCurrentUserID()
      this.isWished = this.findIsWished()
  }
  findIsWished(){
      this.userID = localStorage.getItem("userID");
      return this.card.favoritedByUserDto.find((favorite:any) => favorite.userID == this.userID) !== undefined;
  }
  loadCard(){
    this.card = this.dashboardService.getCard();
    
  }
  addToWish(){
    
    let username = localStorage.getItem("Username")
    let token = localStorage.getItem("Token");
    let isWished = this.findIsWished();
    console.log(this.userID);
    this.dashboardService.addToWish(this.card.adverID, username, token).subscribe(response =>{
      if(!isWished){
        this.card.favoritedByUserDto.push({userID:this.userID, user:null, adverID:this.card.adverID, advertisement:null})
        this.dashboardService.setCard(this.card)
        this.isWished = true;
      }else{
        this.card.favoritedByUserDto = this.card.favoritedByUserDto.filter((favorite: any) => favorite.userID !== this.userID);
        this.dashboardService.setCard(this.card)
        this.isWished = false
      }
      
    }, (error:HttpErrorResponse) =>{
      
    })
  }
  
}
