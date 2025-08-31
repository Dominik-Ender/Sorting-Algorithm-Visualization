import { CONFIG } from './Config.js';
import { DOM } from './DomElements.js';

export class VisualizationService {
    static renderArray(array) {
        DOM.arrayContainer.innerHTML = "";

        array.forEach((num, index) => {
            const div = document.createElement("div");
            div.style.width = "2px";
            div.style.height = num + "px";
            div.style.padding = "2px";
            div.style.border = "1px solid black";
            div.style.textAlign = "center";
            div.style.backgroundColor = this.getColorForIndex(num, array.length);
            DOM.arrayContainer.appendChild(div);
        });
    }
    
    static getColorForIndex(index, total) {
        const colors = CONFIG.COLORS;
        const segments = colors.length - 1;
        const segemenSize = total / segments;
        let segmentIndex = Math.floor(index / segmentSize);

        if (segmentIndex >= segments) {
            segmentIndex = segments - 1;
        }

        const t = (index % segmentSize) / segmentSize;
        const c1 = colors[segmentIndex];
        const c2 = colors[segmentIndex + 1];

        const r = Math.round(c1[0] + (c2[0] - c1[0]) * t);
        const g = Math.round(c1[1] + (c2[1] - c1[1]) * t);
        const b = Math.round(c1[2] + (c2[2] - c1[2]) * t);

        return `rgb(${r},${g},${b})`;
    }
}