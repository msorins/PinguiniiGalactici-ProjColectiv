import {Component, OnInit, Input} from '@angular/core';
import {FormBuilder, FormGroup} from '@angular/forms';
import {Observable} from 'rxjs';
import {startWith, map} from 'rxjs/operators';
import { ConfigService } from 'src/app/_modules/shared/services/client.service';
import { Course } from 'src/app/models/Course';

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
    year: '1st year',
    names: ['Algebra', 'Analiza', 'FP']
  }, {
    year: '2nd year',
    names: ['MAP', 'MPP', 'SDI']
  }, {
    year: '3rd year',
    names: ['Retele']
  }
];

  public groups : any = [931,932,933,934,935,936];

  stateGroupOptions: Observable<StateGroup[]>;

  courses : Course[];

  constructor(private fb: FormBuilder,
    private APIservice : ConfigService
    ) {}

  ngOnInit() {
    this.APIservice.getAllCourses().subscribe(
      data => {
        this.courses = data
      },
      error => {
        console.log("error")
      }
    )

    // this.stateGroupOptions = this.stateForm.get('stateGroup')!.valueChanges
    //   .pipe(
    //     startWith(''),
    //     map(value => this._filterGroup(value))
    //   );
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