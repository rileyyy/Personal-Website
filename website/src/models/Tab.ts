import type { LanguageFn } from 'highlight.js';

export interface Tab {
    code: string;
    materialIcon?: string;
    simpleIcon?: string;
    filename: string;
    mainPane: boolean;
    language: LanguageFn;
}