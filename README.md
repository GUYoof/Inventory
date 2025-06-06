## 🏠 메인 화면 (UIMainMenu)
### 구성 요소

- ID: Text

- 레벨: Text + 경험치 상태 바 (→ Character Script에서 정보 가져옴)

- 골드: 아이콘(Image) + 수량(Text)

- Status 버튼

- Inventory 버튼

## 📊 캐릭터 상태창 (UIStatus)
### 공통 표시 항목

- ID, 레벨, 경험치 상태 바, 골드 (→ Character Script 기반)

### 스탯 영역

- Main Text: "캐릭터 정보"

- 각 스탯에 대한:

- 아이콘(Image)

  - 수치(Text) → Character의 실제 스탯 정보와 연동

- 뒤로가기 버튼

## 🎒 인벤토리 화면 (UIInventory)
### 공통 표시 항목

- ID, 레벨, 경험치 상태 바, 골드 (→ Character Script 기반)

### 인벤토리 영역

- Main Text: "Inventory"

- 수량 표시: 현재 보유 아이템 수 / 최대 수량 (Text)

-  아이템 목록

  - 정렬된 형태로 UI에 표시

  - 아이템 클릭 시:

    - 장착되지 않은 상태 → 장착
  
    - 같은 타입의 기존 아이템이 있다면 해제 후 새로 장착

    - 이미 장착된 상태 → 해제

  - 장착된 아이템은 E 마크로 표시

  - 장착 시 → Character 스탯에 실시간 반영

  - 수량 초과 시: 스크롤(휠) 사용하여 하단 아이템까지 확인 가능

- 뒤로가기 버튼
