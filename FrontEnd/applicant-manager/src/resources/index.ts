import { FrameworkConfiguration } from "aurelia-framework";
import { PLATFORM } from "aurelia-framework";

export function configure(config: FrameworkConfiguration): void {
  config.globalResources([PLATFORM.moduleName("./elements/loading-indicator")]);
}
