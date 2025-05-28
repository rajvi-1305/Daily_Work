import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
// You need to render the Appcomponent at the top
bootstrapApplication(AppComponent, appConfig).catch((err) =>
  console.error(err)
);
