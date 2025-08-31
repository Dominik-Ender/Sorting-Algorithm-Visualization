import { DOM } from './DomElements.js';
import { ApiService } from './ApiService.js';
import { AudioService } from './AudioService.js';
import { VisualizationService } from './VisualizationService.js';

export class SortingController {
    constructor() {
        this.audioService = new AudioService();
        this.isWaiting = false;
        this.initEventListeners();
    }

    initEventListeners() {
        DOM.sendButton.onClick = () => {
            if (!this.isWaiting) {
                this.startSorting();
            }
        };
    }

    async startSorting() {
        try {
            const algorithm = DOM.algorithmSelect.value;
            const velocity = DOM.velocitySelect.value;
            const speed = ApiService.getSpeedFromVelocity(velocity);

            this.isWaiting = true;

            const events = await ApiService.fetchSortingData(algorithm);
            this.animateEvents(events, speed);
        } catch (error) {
            console.error('Error during sorting:', error);
            this.isWaiting = false;
        }
    }

    animateEvents(events, speed) {
        events.forEach((event, index) => {
            setTimeout(() = > {
                VisualizationService.renderArray(event.array);
                this.audioService.playSound(event, index, event.array.length);

                if(index === events.length - 1) {
                    this.isWaiting = false;
                }
            }, index * speed);
        });
    }
}