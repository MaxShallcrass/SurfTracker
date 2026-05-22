# UI Context

## Theme

Dark only. No light mode. The design language is a deep ocean workspace — near-black navy
backgrounds, layered dark surfaces, and bright cyan accents for interactive elements. The
palette evokes being underwater at night: deep, calm, and immersive. All surfaces are flat
with no gradients, no glow effects, and no drop shadows. Contrast is achieved through
layered navy tones rather than light/dark switching.

## Colors

All components must use these tokens — no hardcoded hex values. Custom tokens are the source of truth. Ionic's own CSS variables are mapped to these tokens in
`src/theme/variables.css` and must never be set independently.

| Role             | CSS Variable        | Value     |
| ---------------- | ------------------- | --------- |
| Page background  | `--bg-base`         | `#0A1628` |
| Surface          | `--bg-surface`      | `#0F1F35` |
| Elevated surface | `--bg-elevated`     | `#162840` |
| Subtle surface   | `--bg-subtle`       | `#0C1C2E` |
| Primary text     | `--text-primary`    | `#E8F4FF` |
| Secondary text   | `--text-secondary`  | `#8AAEC8` |
| Muted text       | `--text-muted`      | `#4A7FA8` |
| Faint text       | `--text-faint`      | `#2D5578` |
| Primary accent   | `--accent-primary`  | `#5BB3F0` |
| Default border   | `--border-default`  | `#1A3050` |
| Subtle border    | `--border-subtle`   | `#112238` |
| Error            | `--state-error`     | `#E84855` |
| Success          | `--state-success`   | `#2DD4A0` |


### Usage notes
- `--bg-base` is the page/screen background. Never place content directly on this — always wrap in a surface card.
- `--bg-surface` is used for all cards, bottom sheets, nav bars, and input fields.
- `--accent-primary` is used for primary buttons, condition badges, active tab indicators, and interactive highlights. It must always sit on `--bg-base` or `--bg-surface` backgrounds
  — never on a light surface.
- `--text-muted` is used for labels, subtitles, placeholders, and secondary metadata.
- Borders use `--border-default` at 0.5px throughout. Never increase border width except for a focused input state (1px).

## Typography

| Role          | Font                  | Variable        |
| ------------- | --------------------- | --------------- |
| Headings / display | Bricolage Grotesque | `--font-display` |
| UI text / body | DM Sans              | `--font-sans`   |
| Code / mono   | DM Mono               | `--font-mono`   |

### Usage notes
- `--font-display` (Bricolage Grotesque) is used for screen titles, spot names, section headings, and large stat numbers (wave count, rating, duration).
- `--font-sans` (DM Sans) is used for all body copy, labels, badges, button text, subtitles, and metadata.
- `--font-mono` (DM Mono) is used for any numeric data displayed in a monospaced context such as coordinates or timestamps.
- Font weights: 400 (regular) for body, 500 (medium) for labels and buttons, 600 (semibold) for headings and display numbers.
- Load both fonts from Google Fonts:
  `https://fonts.googleapis.com/css2?family=Bricolage+Grotesque:wght@400;500;600&family=DM+Sans:wght@400;500&family=DM+Mono&display=swap`

## Border Radius

| Context             | Value    | Usage                                      |
| ------------------- | -------- | ------------------------------------------ |
| Inline / small UI   | `6px`    | Input fields, small tags, icon buttons     |
| Cards / panels      | `14px`   | Session cards, spot cards, stat containers |
| Buttons             | `10px`   | Primary and secondary action buttons       |
| Modals / overlays   | `18px`   | Bottom sheets, modal dialogs               |
| Badges / pills      | `999px`  | Condition badges (swell, wind, tide)       |

## Component Library

Ionic components only — no additional component library. Use Ionic's built-in components
as the foundation and customise via CSS variables to match this design system.

### Key Ionic components in use
- `ion-page` / `ion-content` — page and scroll containers
- `ion-header` / `ion-toolbar` — top navigation bars
- `ion-tab-bar` / `ion-tab-button` — bottom tab navigation
- `ion-card` — session and spot cards (override default styles with surface tokens)
- `ion-item` / `ion-list` — form rows and list views
- `ion-input` / `ion-select` / `ion-textarea` — form inputs
- `ion-button` — primary and secondary actions
- `ion-modal` — bottom sheet overlays for session logging
- `ion-badge` — condition pills (swell, wind, tide)
- `ion-skeleton-text` — loading states

### Customisation approach
Override Ionic CSS variables globally in `src/theme/variables.css` to apply this design system.
Do not write custom CSS that duplicates what Ionic variables already control.

## Layout Patterns

- **Bottom tab navigation** — primary navigation lives in a fixed `ion-tab-bar` at the bottom of the screen with 3 tabs: Log, History, Spots.
- **Screen header** — each screen uses an `ion-header` with `ion-toolbar` containing the screen title in `--font-display`
- **Bottom sheet modal** — session logging uses a full-height `ion-modal` that slides up from the bottom with 18px top border radius and `--bg-surface` background.

## Icons

Ionicons — outline style only. Built into Ionic, no additional install required.

### Usage
- Import named icons from `ionicons/icons` and pass to the `ion-icon` component.
- Use outline variants exclusively (e.g. `homeOutline`, `addOutline`, `waveOutline`). Never use filled variants in this design system.
- Sizes: 20px for tab bar icons, 22px for header action icons, 16px for inline content icons, 48px for empty state illustrations.
- Icon colour inherits from parent — never set icon colour directly. Rely on the parent element's `--text-primary` or `--text-muted` token.

### Common icons mapped to app features
| Feature             | Ionicon name           |
| ------------------- | ---------------------- |
|   tab        | `calendarOutline`      |
| Spots tab           | `locationOutline`      |
| Log session tab     | `addCircleOutline`     |
| Profile tab         | `personOutline`        |
| Wave / swell        | `waterOutline`         |
| Wind                | `cloudyOutline`        |
| Tide                | `thermometerOutline`   |
| Duration            | `timeOutline`          |
| Rating              | `starOutline`          |
| Delete session      | `trashOutline`         |
| Back navigation     | `chevronBackOutline`   |
| Empty state (general) | `fishOutline`        |
