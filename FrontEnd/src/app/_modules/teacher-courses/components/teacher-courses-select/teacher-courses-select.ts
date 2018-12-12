import {Component, OnInit, Input} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {Observable} from 'rxjs';
import {startWith, map} from 'rxjs/operators';
import { Course } from 'src/app/models/Course';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';
import { EventEmitter, Output } from '@angular/core';

export interface StateGroup {
  year: string;
  names: string[];
}

export const _filter = (opt: string[], value: string): string[] => {
  const filterValue = value.toLowerCase();

  return opt.filter(item => item.toLowerCase().indexOf(filterValue) === 0);
};

/**
 * @title Option groups autocomplete
 */
@Component({
  selector: 'app-teacher-courses-select',
  templateUrl: './teacher-courses-select.html',
  styleUrls: ['./teacher-courses-select.css'],
  inputs: ['courses']
})

export class TeacherCoursesSelectComponent implements OnInit {
  @Input() courses: Course[];
  @Output() selectedCourse: EventEmitter<Course> = new EventEmitter<Course>() ;
  @Output() selectedGroup:  EventEmitter<Number> = new EventEmitter<Number>() ;

  stateForm: FormGroup = this.fb.group({
    stateGroup: '',
  });

  stateGroups: StateGroup[] = [{
      year: 'Courses',
      names: []
    }
  ];

  private groups : any = [];
  stateGroupOptions: Observable<StateGroup[]>;

  constructor(private fb: FormBuilder) {}

  ngOnChanges(courses: Course[]): void {
    this.courses.forEach(element => {
      this.stateGroups[0].names.push(element.Name);
    });
    
  }

  ngOnInit() {
    this.stateGroupOptions = this.stateForm.get('stateGroup')!.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filterGroup(value))
      );
  }

  private _filterGroup(value: string): StateGroup[] {
    this.updateGroups(value);
    if (value) {
      return this.stateGroups
        .map(group => ({year: group.year, names: _filter(group.names, value)}))
        .filter(group => group.names.length > 0);
    }

    return this.stateGroups;
  }

  private updateGroups(value: string) {
    if(this.courses != null) {
      this.courses.forEach(element => {
        if(element.Name == value) {
          // It means that a valid course was chosen
          this.selectedCourse.emit(element);

          if(element.Year == 1) {
            this.groups = [911, 912, 913, 914, 915, 916, 917]
          }
          if(element.Year == 2) {
            this.groups = [921, 922, 923, 924, 925, 926, 927]
          }
          if(element.Year == 3) {
            this.groups = [931, 932, 933, 934, 935, 936]
          }
        }
      });
    }
  }

  public groupSelected(event: number) {
    this.selectedGroup.emit(event);
  }
}
