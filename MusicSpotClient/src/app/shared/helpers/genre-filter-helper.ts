import { DropdownItem } from '../components/dropdown/dropdown.component';
import { GenreEnum } from '../enums/enums';

export class  GenreFilterHelper{

    public static createGenreDropdownItemList(): DropdownItem[]{
        return [
         <DropdownItem>
         {
            id:   "-1",
            name: "ALL"
         },
        <DropdownItem>
        {
           id:   GenreEnum.Rock.toString(),
           name: "ROCK"
        },
        {
            id:   GenreEnum.Pop.toString(),
            name: "POP"
         },
         {
            id:   GenreEnum.Indie.toString(),
            name: "INDIE"
         },
         {
            id:   GenreEnum.Metal.toString(),
            name: "METAL"
         },
         {
            id:   GenreEnum.Classical.toString(),
            name: "CLASSICAL"
         },
         {
            id:   GenreEnum.House.toString(),
            name: "HOUSE"
         },
         {
            id:   GenreEnum.HipHop.toString(),
            name: "HIPHOP"
         },
         {
            id:   GenreEnum.Jazz.toString(),
            name: "JAZZ"
         },
         {
            id:   GenreEnum.Rap.toString(),
            name: "RAP"
         },
         {
            id:   GenreEnum.Raggae.toString(),
            name: "RAGGAE"
         },
         {
            id:   GenreEnum.Punk.toString(),
            name: "PUNK"
         },
         {
            id:   GenreEnum.Disco.toString(),
            name: "DISCO"
         },
         {
            id:   GenreEnum.Electronica.toString(),
            name: "ELECTRONICA"
         },
         {
            id:   GenreEnum.Dance.toString(),
            name: "DANCE"
         },
         {
            id:   GenreEnum.Techno.toString(),
            name: "TECHNO"
         },
         {
            id:   GenreEnum.Folk.toString(),
            name: "FOLK"
         }];
    }
}
