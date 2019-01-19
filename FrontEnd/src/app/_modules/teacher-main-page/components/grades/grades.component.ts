import {Component, OnInit} from '@angular/core';

export interface PeriodicElement {
  name: string;
  position: number;
  S1: string;
  S2: string;
  S3: string;
  S4: string;
  S5: string;
  S6: string;
  S7: string;
  S8: string;
  S9: string;
  S10: string;
  S11: string;
  S12: string;
  S13: string;
  S14: string;
}


const ELEMENT_DATA: PeriodicElement[] = [
  {
    position: 1,
    name: 'Hydrogen',
    S1: '1.0079',
    S2: '1.0079',
    S3: '1.0079',
    S4: '1.0079',
    S5: '1.0079',
    S6: '1.0079',
    S7: '1.0079',
    S8: '1.0079',
    S9: '1.0079',
    S10: '1.0079',
    S11: '1.0079',
    S12: '1.0079',
    S13: '1.0079',
    S14: '1.0079'
  },
  {
    position: 2,
    name: 'Helium',
    S1: '1.0079',
    S2: '1.0079',
    S3: '1.0079',
    S4: '1.0079',
    S5: '1.0079',
    S6: '1.0079',
    S7: '1.0079',
    S8: '1.0079',
    S9: '1.0079',
    S10: '1.0079',
    S11: '1.0079',
    S12: '1.0079',
    S13: '1.0079',
    S14: '1.0079'
  },
  {
    position: 3,
    name: 'Lithium',
    S1: '1.0079',
    S2: '1.0079',
    S3: '1.0079',
    S4: '1.0079',
    S5: '1.0079',
    S6: '1.0079',
    S7: '1.0079',
    S8: '1.0079',
    S9: '1.0079',
    S10: '1.0079',
    S11: '1.0079',
    S12: '1.0079',
    S13: '1.0079',
    S14: '1.0079'
  },
  // {position: 4, name: 'Beryllium', email: '1.0079'},
  // {position: 5, name: 'Boron', email: '1.0079'},
  // {position: 6, name: 'Carbon', email: '1.0079'},
  // {position: 7, name: 'Nitrogen', email: '1.0079'},
  // {position: 8, name: 'Oxygen', email: '1.0079'},
  // {position: 9, name: 'Fluorine', email: '1.0079'},
  // {position: 10, name: 'Neon', email: '1.0079'},
];

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.css']
})
export class GradesComponent implements OnInit {
  displayedColumns: string[] = ['position', 'name', 'S1', 'S2', 'S3',
    'S4', 'S5', 'S6', 'S7', 'S8', 'S9', 'S10', 'S11', 'S12', 'S13', 'S14'];
  dataSource = ELEMENT_DATA;

  constructor() {
  }

  ngOnInit() {
  }
}
