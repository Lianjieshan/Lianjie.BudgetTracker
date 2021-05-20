import {Income} from './incomes';
import {Expenditure} from './expenditures';

export interface UserDetails {
    id: number;
    email: string;
    fullName: string;
    totalIncomes: number;
    totalExpenditures: number;
    incomes: Income[];
    expenditures: Expenditure[];
}