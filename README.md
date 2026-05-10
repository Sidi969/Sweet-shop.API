# 🍰 Dyqan Ëmbëlsirash

Projekt final me **Front-end** (HTML) dhe **Back-end** (Node.js API).

---

## 📁 Struktura

```
SweetShop.API.Node/     ← Back-end (Node.js + Express)
  index.js
  data.json
  package.json

SweetShop.Client/       ← Front-end (HTML)
  index.html
  add-sweet.html
  edit-sweet.html
  scripts/config.js
```

---

## 🌐 Si ta publikosh nga TELEFONI (pa PC)

### Hapi 1 — Krijo account në GitHub
Shko te **github.com** dhe regjistrohu falas.

### Hapi 2 — Krijo 2 repository të veçanta

**Repository 1 — API (Back-end):**
1. Kliko `+` → `New repository`
2. Emri: `SweetShop.API` → Public → `Create repository`
3. Kliko `uploading an existing file`
4. Ngarko: `index.js`, `data.json`, `package.json`
5. Kliko `Commit changes`

**Repository 2 — Client (Front-end):**
1. Krijo repository tjetër: `SweetShop.Client` → Public
2. Ngarko: `index.html`, `add-sweet.html`, `edit-sweet.html`
3. Krijo folder `scripts/` dhe ngarko `config.js` brenda saj

### Hapi 3 — Publiko API-n falas në Render.com
1. Shko te **render.com** → regjistrohu me GitHub
2. `New` → `Web Service` → Zgjidh `SweetShop.API`
3. Build Command: `npm install`
4. Start Command: `node index.js`
5. Kliko `Deploy` dhe prit ~3 minuta
6. Kopjo URL-në (p.sh. `https://sweetshop-api-xxxx.onrender.com`)

### Hapi 4 — Vendos URL-në e API-t në Front-end
Hap `scripts/config.js` në GitHub dhe ndrysho:
```js
const API_URL = "https://sweetshop-api-xxxx.onrender.com";
```

### Hapi 5 — Aktivo GitHub Pages për Front-end
1. Shko te repository `SweetShop.Client`
2. `Settings` → `Pages` → Source: `main` → `Save`
3. URL-ja do të jetë: `https://USERNAME.github.io/SweetShop.Client`

---

## ✅ Dorëzo këto 2 linke tek profesori:
- **API:** `https://sweetshop-api-xxxx.onrender.com`
- **Client:** `https://USERNAME.github.io/SweetShop.Client`
