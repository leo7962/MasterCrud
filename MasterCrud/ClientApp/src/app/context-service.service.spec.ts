import {TestBed} from '@angular/core/testing';

import {ContextServiceService} from './context-service.service';

describe('ContextServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ContextServiceService = TestBed.get(ContextServiceService);
    expect(service).toBeTruthy();
  });
});
