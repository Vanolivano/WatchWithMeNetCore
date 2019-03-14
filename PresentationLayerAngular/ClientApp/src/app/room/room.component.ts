import { Component } from '@angular/core';
import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer} from '@angular/platform-browser';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css'],
})
export class RoomComponent {
  public url = "https://www.youtube.com/embed/5CAPMA8f68U";
  public transformUrl(url:string){
    if (url == '' || url == null){ return; }
    let schema = "https://www.youtube.com/embed/";
    let idVideo =  RoomComponent.convertYoutube(url);
    if(idVideo != null)
      this.url = schema + idVideo;
  }
  private static convertYoutube(url:string){
    let re = /^(https?:\/\/)?((www\.)?(youtube(-nocookie)?|youtube.googleapis)\.com.*(v\/|v=|vi=|vi\/|e\/|embed\/|user\/.*\/u\/\d+\/)|youtu\.be\/)([_0-9a-z-]+)/i;
    let result = url.match(re);
    if(result != null){
      return url.match(re)[7];
    } else {
      return null;
    }
  }
}

@Pipe({ name: 'safe' })
export class SafePipe implements PipeTransform {

  constructor(private sanitizer: DomSanitizer) {}
  public transform(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}
