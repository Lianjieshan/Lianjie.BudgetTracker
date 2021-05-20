import {Income} from './incomes';
import {Expenditure} from './expenditures';

export interface UserCreate {
    email: string;
    fullname: string;
    joinedOn: Date;
    incomes: Income[];
    expenditures: Expenditure[];
}