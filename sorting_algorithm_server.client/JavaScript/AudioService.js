import { CONFIG } from './Config.js';

export class AudioService {
    constructor() {
        this.audioContext = new (window.AudioContext || window.webkitAudioContext)();
    }

    playSound(index, total) {
        const freq = CONFIG.SOUND.minFreq + (index / total) * (CONFIG.SOUND.maxFreq - CONFIG.SOUND.minFreq);

        const oscillator = this.audioContext.createOscillator();
        oscillator.type = "square";
        oscillator.frequency.setValueAtTime(freq, this.audioContext.currentTime);

        const gainNode = this.audioContext.createGain();
        gainNode.gain.setValueAtTime(CONFIG.SOUND.volume, this.audioContext.currentTime);
        gainNode.gain.exponentialRampToValueAtTime(0.001, this.audioContext.currentTime + CONFIG.SOUND.duration);

        oscillator.connect(gainNode);
        gainNode.connect(this.audioContext.destination);
        oscillator.start();
        oscillator.stop(this.audioContext.currentTime + CONFIG.SOUND.duration);
    }
}