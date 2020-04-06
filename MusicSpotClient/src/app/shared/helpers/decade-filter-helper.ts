import { DropdownItem } from '../components/dropdown/dropdown.component';
import { DecadeEnum } from '../enums/enums';

export class  DecadeFilterHelper{

    public static createDecadeDropdownItemList(): DropdownItem[]{
        return [
         <DropdownItem>
         {
            id:   "-1",
            name: "ALL"
         },
        <DropdownItem>
        {
           id:   DecadeEnum.D2010_2020.toString(),
           name: "2010 - 2020"
        },
        <DropdownItem>
        {
           id:   DecadeEnum.D2000_2010.toString(),
           name: "2000 - 2010"
        },
        <DropdownItem>
        {
           id:   DecadeEnum.D1990_2000.toString(),
           name: "1990 - 2000"
        },
        <DropdownItem>
        {
           id:   DecadeEnum.D1980_1990.toString(),
           name: "1980 - 1990"
        },
        <DropdownItem>
        {
           id:   DecadeEnum.D1970_1980.toString(),
           name: "1970 - 1980"
        },
        <DropdownItem>
        {
           id:   DecadeEnum.D1960_1970.toString(),
           name: "1960 - 1970"
        },
        <DropdownItem>
        {
           id:   DecadeEnum.D1950_1960.toString(),
           name: "1950 - 1960"
        },
        ];
    }
}
