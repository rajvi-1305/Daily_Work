import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: HomepageComponent },
  { path: 'dashboard', component: DashboardComponent },
];
