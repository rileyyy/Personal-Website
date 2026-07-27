import type { LanguageFn } from 'highlight.js';

export interface Tab {
    code: string;
    icon: string;
    filename: string;
    mainPane: boolean;
    language: LanguageFn;
}