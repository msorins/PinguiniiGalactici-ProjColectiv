import {Component, OnInit, Input} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {Observable} from 'rxjs';
import {startWith, map} from 'rxjs/operators';
import { Course } from 'src/app/models/Course';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';

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

  stateForm: FormGroup = this.fb.group({
    stateGroup: '',
  });

  stateGroups: StateGroup[] = [{
    year: 'Courses',
    names: []
  }
];

  public groups : any = [931,932,933,934,935,936];

  stateGroupOptions: Observable<StateGroup[]>;


  constructor(private fb: FormBuilder, private _TeacherCoursesService: TeacherCoursesService) {}

  ngOnInit() {
    this._TeacherCoursesService.getCourses().subscribe(
      data => {
        this.courses = data
        this.courses.forEach(element => {
          this.stateGroups[0].names.push(element.Name);
        });
        
      }
    )

    this.stateGroupOptions = this.stateForm.get('stateGroup')!.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filterGroup(value))
      );
  }

  private _filterGroup(value: string): StateGroup[] {
    console.log(value);
    if (value) {
      return this.stateGroups
        .map(group => ({year: group.year, names: _filter(group.names, value)}))
        .filter(group => group.names.length > 0);
    }

    return this.stateGroups;
  }
}