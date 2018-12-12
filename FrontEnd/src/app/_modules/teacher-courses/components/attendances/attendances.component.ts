import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';


export interface Student {
  name: string;
  email: string;
  present: boolean[];  
}

const STUDENTS_DATA: Student[] = [
  {name: 'Nazarie Ciprian', email: "a@gmail.com",
   present: [false, true, false, false, true, true, true, false,
     false, false, false, true, true, true, false]
  },
  {name: 'Nechita Sebastian',  email: "a@gmail.com", 
    present: [false, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Mircea Sorin',  email: "a@gmail.com", 
    present: [false, true, false, false, true, true, true, false,
      false, false, false, true, false, true, true, true, false,]
  },
  {name: 'Vieriu Denis',  email: "a@gmail.com", 
    present: [true, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Mircea Madalina',  email: "a@gmail.com", 
    present: [false, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Moisuc Naomi',  email: "a@gmail.com", 
  
    present: [false, false, false, true, true, true, false,
      false, true, false, false, true, true, true, false,]
  },
  {name: 'Nazarie Ciprian', email: "a@gmail.com",
   present: [false, true, false, false, true, true, true, false,
     false, false, false, true, true, true, false]
  },
  {name: 'Nechita Sebastian',  email: "a@gmail.com", 
    present: [false, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Mircea Sorin',  email: "a@gmail.com", 
    present: [false, true, false, false, true, true, true, false,
      false, false, false, true, false, true, true, true, false,]
  },
  {name: 'Vieriu Denis',  email: "a@gmail.com", 
    present: [true, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Mircea Madalina',  email: "a@gmail.com", 
    present: [false, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Moisuc Naomi',  email: "a@gmail.com", 
    present: [false, false, false, true, true, true, false,
      false, true, false, false, true, true, true, false,]
  },
];

@Component({
  selector: 'app-attendances',
  templateUrl: './attendances.component.html',
  styleUrls: ['./attendances.component.css']
})
export class AttendancesComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'week1', 'week2', 'week3', 'week4',
  'week5', 'week6', 'week7', 'week8', 'week9', 'week10', 'week11', 'week12', 'week13', 'week14'
  ];
  dataSource = new MatTableDataSource(STUDENTS_DATA);

  constructor() { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataSource.sort = this.sort;
  }

 
  applyFilter(filterValue: string) {
    //todo: add custom filter only by name
    this.dataSource.filter = filterValue.trim();
  }

  onChecked(element, position): void {
    //bug :-?
    // element.present[position] = !element.present[position]
    console.log(element, position);
    //todo
  }

}
