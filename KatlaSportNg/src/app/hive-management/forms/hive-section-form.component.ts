import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSection } from '../models/hive-section';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})

export class HiveSectionFormComponent implements OnInit {

  hiveSection = new HiveSection(0, "", "", 0, false, "");
  existed = false;
  storeHiveId: number;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.storeHiveId = p['hiveId'];
      if (p['id'] === undefined) return;
      this.hiveSectionService.getHiveSection(p['id']).subscribe(s => this.hiveSection = s, error => alert(this.errorService.handleError(error)));
      this.existed = true;
    });
  }

  onCancel() {
    this.navigateToSections();
  }

  onSubmit() {
    this.hiveSection.storeHiveId = this.storeHiveId;
    if (this.existed) {
      this.hiveSectionService
        .updateHiveSection(this.hiveSection).subscribe(p => this.navigateToSections());
    }
    else {
      this.hiveSectionService.addHiveSection(this.hiveSection).subscribe(p => this.navigateToSections());
    }
  }

  onDelete() {
    this.hiveSectionService.
      setHiveSectionStatus(this.hiveSection.id, true).subscribe(c => this.hiveSection.isDeleted = true);
  }

  onUndelete() {
    this.hiveSectionService.setHiveSectionStatus
      (this.hiveSection.id, false).subscribe(c => this.hiveSection.isDeleted = false);
  }

  onPurge() {
    this.hiveSectionService.deleteHiveSection(this.hiveSection.id).
      subscribe(c => this.navigateToSections());
  }

  navigateToSections() {
    this.router.navigate([`/hive/${this.storeHiveId}/sections`]);
  }
}
