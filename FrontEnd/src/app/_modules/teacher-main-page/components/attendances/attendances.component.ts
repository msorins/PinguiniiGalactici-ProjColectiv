import { Component, OnInit } from '@angular/core';
import { ViewEncapsulation } from '@angular/compiler/src/core';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Nazarie Ciprian', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Nechita Sebastian', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Vieriu Denis', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Mircea Sorin', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Mircea Madalina', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Moisuc Naomi', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Jugaru Robert', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Mihalache Mihai', weight: 15.9994, symbol: 'O'},
  {position: 1, name: 'Nazarie Ciprian', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Nechita Sebastian', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Vieriu Denis', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Mircea Sorin', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Mircea Madalina', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Moisuc Naomi', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Jugaru Robert', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Mihalache Mihai', weight: 15.9994, symbol: 'O'},
  {position: 1, name: 'Nazarie Ciprian', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Nechita Sebastian', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Vieriu Denis', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Mircea Sorin', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Mircea Madalina', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Moisuc Naomi', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Jugaru Robert', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Mihalache Mihai', weight: 15.9994, symbol: 'O'},
  {position: 1, name: 'Nazarie Ciprian', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Nechita Sebastian', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Vieriu Denis', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Mircea Sorin', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Mircea Madalina', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Moisuc Naomi', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Jugaru Robert', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Mihalache Mihai', weight: 15.9994, symbol: 'O'},
];

@Component({
  selector: 'app-attendances',
  templateUrl: './attendances.component.html',
  styleUrls: ['./attendances.component.css']
})
export class AttendancesComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  displayedColumns: string[] = ['position', 'name','week1', 'week2', 'week3', 'week4',
  'week5', 'week6', 'week7', 'week8', 'week9', 'week10', 'week11', 'week12', 'week13', 'week14'
  ];
  dataSource = ELEMENT_DATA;

}
