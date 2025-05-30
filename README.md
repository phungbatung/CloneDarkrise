# Giới thiệu Dự án

Đây là một dự án chưa hoàn thiện, được clone từ game gốc: [Darkrise trên Google Play](https://play.google.com/store/apps/details?id=com.Roika.Darkrise).

## Mô tả chi tiết các chức năng chính của hệ thống

### 1. Hệ thống Combat

Chỉ số (stat) được chia thành ba nhóm:

- **Offensive:**
  - `damage`
  - `attackSpeed`
  - `armorPenetration`
  - `criticalRate`
  - `criticalDamage`

- **Defensive:**
  - `maxHealth`
  - `healthRegen`
  - `armor`

- **Special:**
  - `maxMana`
  - `manaRegen`
  - `moveSpeed`

---

### 2. Hệ thống Item

- **Equipment:**
  - Bao gồm 8 loại nhỏ (weapon, shield, boots, gauntlets, ...).
  - Mỗi trang bị khi rơi ra sẽ nhận được chỉ số (stat) ngẫu nhiên với giá trị trong khoảng **70%-130%** chỉ số gốc.
  - Trang bị phẩm chất càng cao thì nhận được càng nhiều dòng chỉ số.

- **SkillBook:**
  - Sử dụng để nhận điểm kỹ năng.
  - Giá trị điểm kỹ năng tùy thuộc vào phẩm chất của item.

- **MagicDust:**
  - Dùng để khảm vào equipment nhằm tăng chỉ số cho nhân vật.
  - Tương tự như Gem trong một số game khác (dùng MagicDust để thay thế do thiếu asset).

- **Potion:**
  - Bình hồi phục (health hoặc mana).
  - Có thể sử dụng trong Inventory hoặc gán vào slot để tiện sử dụng.
  - Có thời gian hồi chiêu.

- **Buff:**
  - Dùng để tăng chỉ số tạm thời.
  - **Lưu ý:** Chức năng này hiện đang bị lỗi do quá trình chuyển đổi hệ thống UI.

---

### 3. Hệ thống Skill

- Sử dụng điểm kỹ năng (nhận được từ SkillBook) để nâng cấp kỹ năng.
- Có thể gán kỹ năng mong muốn ra màn hình chính để sử dụng.

---

### 4. Hệ thống Level

- Người chơi tiêu diệt quái để nhận Exp và lên cấp.
- Quái có level càng cao thì chỉ số càng mạnh.

---

### 5. Hệ thống SkillTree (PassiveSkill)

- Sử dụng điểm nâng cấp để mở các node trên graph.
- Mỗi node khi mở sẽ mang lại phần thưởng tương ứng (thường là stat).
- Chỉ có thể mở các node liền kề với các node đã được mở.
- **Hiện tại:** Chỉ có node tăng stat, chưa có node kỹ năng (sẽ được bổ sung sau).

---

### 6. Hệ thống Map

- Người chơi sử dụng **cổng dịch chuyển** để teleport đến một map mới.
- Khi đã di chuyển đến một map, người chơi có thể **dịch chuyển trực tiếp** đến đó sau này bằng **tháp dịch chuyển** (teleport tower).

---

### 7. Hệ thống NPC

- **ShopPotion:** Mua potion.
- **UpgradeEquipment:** Nâng cấp trang bị.
- **GemInsertion:** Đục lỗ và gắn gem.

---

### 8. Hệ thống UI

- Mỗi hệ thống sẽ có một hoặc nhiều giao diện UI tương ứng.
- Các UI được xây dựng theo cơ chế **LIFO (Stack)**:
  - Mỗi khi mở một màn hình mới, UI sẽ được `Push` chồng lên UI hiện tại.
  - Khi tắt UI, màn hình sẽ được `Pop` để hiển thị lại UI bên dưới trong Stack.
