import React from 'react';
import { Authenticator, ThemeProvider, createTheme } from '@aws-amplify/ui-react';
import './Login.css';

const amplifyTheme = createTheme({
  name: 'surf-tracker',
  tokens: {
    // --- Colours ---
    colors: {
      background: {
        primary:   { value: 'var(--bg-base)' },
        secondary: { value: 'var(--bg-surface)' },
      },
      // Brand scale drives primary buttons, active tabs, focus rings.
      // 10–60 map to design system surfaces/borders; 80 is the main accent.
      // 90 and 100 are lighter hover/focus shades — no variable exists for these.
      brand: {
        primary: {
          10:  { value: 'var(--bg-base)' },
          20:  { value: 'var(--bg-subtle)' },
          40:  { value: 'var(--border-subtle)' },
          60:  { value: 'var(--border-default)' },
          80:  { value: 'var(--accent-primary)' },
          90:  { value: 'var(--accent-hover)' },
          100: { value: 'var(--accent-focus)' },
        },
      },
      font: {
        primary:     { value: 'var(--text-primary)' },
        secondary:   { value: 'var(--text-secondary)' },
        tertiary:    { value: 'var(--text-muted)' },
        interactive: { value: 'var(--accent-primary)' },
        hover:       { value: 'var(--accent-hover)' },
        focus:       { value: 'var(--accent-focus)' },
        disabled:    { value: 'var(--text-faint)' },
      },
      border: {
        primary:   { value: 'var(--border-default)' },
        secondary: { value: 'var(--border-subtle)' },
        focus:     { value: 'var(--accent-primary)' },
      },
    },

    // --- Typography ---
    fonts: {
      default: {
        variable: { value: 'var(--font-sans)' },
        static:   { value: 'var(--font-sans)' },
      },
    },

    // --- Radii (from ui-context border-radius table) ---
    radii: {
      small:  { value: '6px' },   // inputs, small UI
      medium: { value: '10px' },  // buttons
      large:  { value: '14px' },  // cards / the auth panel
      xl:     { value: '18px' },  // modals
    },

    // --- Component overrides ---
    components: {
      authenticator: {
        router: {
          backgroundColor: { value: 'var(--bg-surface)' },
          borderWidth:     { value: '0.5px' },
          borderStyle:     { value: 'solid' },
          borderColor:     { value: 'var(--border-default)' },
          boxShadow:       { value: 'none' },
          // borderRadius not exposed as a token — set via CSS in Login.css
        },
      },

      button: {
        primary: {
          backgroundColor: { value: 'var(--accent-primary)' },
          color:           { value: 'var(--bg-base)' },
          _hover: {
            backgroundColor: { value: 'var(--accent-hover)' },
            color:           { value: 'var(--bg-base)' },
          },
          _active: {
            backgroundColor: { value: 'var(--accent-active)' },
            color:           { value: 'var(--bg-base)' },
          },
          _focus: {
            backgroundColor: { value: 'var(--accent-primary)' },
            color:           { value: 'var(--bg-base)' },
            boxShadow:       { value: 'none' },
          },
        },
        link: {
          color: { value: 'var(--accent-primary)' },
          _hover: {
            color:           { value: 'var(--accent-hover)' },
            backgroundColor: { value: 'transparent' },
          },
          _focus: {
            boxShadow: { value: 'none' },
          },
        },
      },

      // The actual <input> element inside a field
      fieldcontrol: {
        color:        { value: 'var(--text-primary)' },
        // backgroundColor not exposed as token — set via CSS in Login.css
        borderColor:  { value: 'var(--border-default)' },
        borderWidth:  { value: '0.5px' },
        borderRadius: { value: '6px' },
        _focus: {
          borderColor: { value: 'var(--accent-primary)' },
          // borderWidth not exposed on _focus — 1px focus border set via CSS in Login.css
          boxShadow:   { value: 'none' },
        },
      },

      // Sign In / Create Account tabs
      tabs: {
        borderColor: { value: 'var(--border-default)' },
        item: {
          color: { value: 'var(--text-muted)' },
          _hover: {
            color: { value: 'var(--text-secondary)' },
          },
          _active: {
            color:       { value: 'var(--accent-primary)' },
            borderColor: { value: 'var(--accent-primary)' },
          },
          _focus: {
            color:     { value: 'var(--accent-primary)' },
            boxShadow: { value: 'none' },
          },
        },
      },
    },
  },
});

const Login: React.FC = () => (
  <div className="login-page">
    <ThemeProvider theme={amplifyTheme} colorMode="dark">
      <Authenticator />
    </ThemeProvider>
  </div>
);

export default Login;
