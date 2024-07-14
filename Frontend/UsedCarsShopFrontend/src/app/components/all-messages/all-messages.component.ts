import { JsonPipe } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, DoCheck, HostListener, OnChanges, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Messages } from 'src/app/Data Transfer Objects/Messages';
import { LoadingService } from 'src/app/services/loading.service';
import { MessagesService } from 'src/app/services/messages.service';
import { WebsocketMessagesService } from 'src/app/services/websocket-messages.service';

;
@Component({
  selector: 'app-all-messages',
  templateUrl: './all-messages.component.html',
  styleUrls: ['./all-messages.component.scss']
})
export class AllMessagesComponent implements DoCheck, OnInit, OnChanges{
 
    private readonly _messageService:MessagesService 
    messageObject:Messages;
    currentUsername = localStorage.getItem("Username")
    currentUrl = this.router.url;
    isSelectedValue = localStorage.getItem("isSelected");
    messageID:any
    isSelected = this.isSelectedValue === 'true' ? true : false
    private wsSub:any;
    oldMessages:any

    isLoading:boolean = false;
    // private messageEventSubscription:Subscription;
    constructor(private messagesService:MessagesService,private router:Router,  private route:ActivatedRoute, private wsService:WebsocketMessagesService, private loadingService:LoadingService){
        this._messageService = messagesService;
        this.messageObject = new Messages();
        // this.messageEventSubscription = this.messagesService.newMessage$.subscribe(
        //   data => this.handleNewMessage(data)
        // );
    }

    
    ngDoCheck(): void {

    }
    ngOnInit():void{
      this.loadMessages();
      localStorage.setItem("currentRoute", "Inbox")
    }

    ngOnChanges():void{
   
    }
    ngOnDestroy():void{
      localStorage.removeItem("messageID");
    }
    // handleNewMessage(data:any){
    //   const chat = this.messageObject.Messages.find((msg: any) => msg.initialSenderID === data.initialSenderID && msg.adverID == data.adverID);
    //   console.log("Data: ", data)
    //   if (chat) {
    //     chat.isNew = true;
    //     this.highlightNewChat(chat);
    //   }
    // }
    // highlightNewChat(chat:any){
    //   console.log("Uso funckija")
    //   const chatElement = document.getElementById(`chat-${chat.adverID}-${chat.initialSenderID}`);
    //   if(chatElement){
    //     console.log("uso if")
    //     chatElement.classList.add("new-message")
    //   }
    // }
    sortMessages(){
      this.messageObject.Messages.sort((b,a) => {
        return new Date(a.dateSent).getTime() - new Date(b.dateSent).getTime();
      });
    }
    loadMessages(){
      let username = localStorage.getItem("Username")
      this.isLoading = true
      this._messageService.getUserMessages(username).subscribe(response=>{
        this.messageObject.Messages = response;
        this.sortMessages()
        this.messageID = localStorage.getItem("messageID")
        console.log( this.messageObject.Messages)
        this.oldMessages = localStorage.getItem("oldMessages")
        if(this.oldMessages){
        }else{
          localStorage.setItem("oldMessages",JSON.stringify(this.messageObject.Messages));
        }
       this.isLoading = false
      }, (error:HttpErrorResponse)=>{
        console.log(error);
      })
    }

    highlightNewMessages(){

    }
    selectChat(chat:any){
      this.isSelected = true;
      chat.isSelected = true;
      let isNewPrev = chat.isNew;
      chat.isNew = false;
      this._messageService.setChat(chat);
      this.setToStorage(chat);
      console.log("MessageID: ", chat.messageID)
      if(isNewPrev == true){
        this.messagesService.decrementMessages(1);
        this.messagesService.openMessage(chat.messageID).subscribe((response)=>{
         
        }, (error:HttpErrorResponse)=>{
          console.log(error);
        })
      }
     
      let wsUrl =`${localStorage.getItem("userID")}-${chat.adverID}-${chat.initialSenderID}`;
      localStorage.setItem("wsUrl", wsUrl);
      this.router.navigate([`/Messages/Inbox/Direct/${wsUrl}`])
      
    }
    setToStorage(chat:any){
      localStorage.setItem("adverID", chat.adverID)
      localStorage.setItem("messageID", chat.messageID);
      localStorage.setItem("initialSenderID", chat.initialSenderID)
      localStorage.setItem("isSelected", JSON.stringify(this.isSelected));
    }
 
}

