import { CONFIG } from './Config.js';

export class ApiService {
    static baseUrl = 'https://localhost:7000/sorting/';

    static async fetchSortingData(algorithm) {
        const endpoint = this.baseUrl + algorithm;

        try {
            const request = await fetch(endpoint, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            });

            if (!request.ok) {
                throw new Error(`HTTP error! status: ${request.status}`);
            }

            const events = await request.json();
            return events;
        } catch (error) {
            console.error('Error fetching sorting data: ', error);
            throw error;
        }
    }

    static getSpeedFromVelocity(velocity) {
        return CONFIG.SPEEDS[velocity] || CONFIG.SPEEDS.default;
    }
}