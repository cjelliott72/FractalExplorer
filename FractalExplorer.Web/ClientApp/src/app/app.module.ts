import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatTabsModule, MatSidenavModule, MatToolbarModule, MatIconModule, MatListModule, MatDialogModule } from '@angular/material';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing.module';
import { HomeComponent } from './components/home/home.component';
import { ParametersComponent } from './components/parameters/parameters.component';
import { ExplorerComponent } from './components/explorer/explorer.component';
import { LayoutComponent } from './components/layout/layout.component';
import { HeaderComponent } from './components/header/header.component';
import { SidenavListComponent } from './components/sidenav-list/sidenav-list.component';
import { AboutComponent } from './components/about/about.component';
import { ZoomDialogComponent } from './components/zoom-dialog/zoom-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ParametersComponent,
    ExplorerComponent,
    LayoutComponent,
    HeaderComponent,
    SidenavListComponent,
    AboutComponent,
    ZoomDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatTabsModule,
    FlexLayoutModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    DragDropModule
  ],
  entryComponents: [ZoomDialogComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
