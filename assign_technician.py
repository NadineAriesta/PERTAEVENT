import sqlite3
from datetime import datetime

def main():
    conn = sqlite3.connect('eventsupport.db')
    cursor = conn.cursor()
    
    try:
        # Event 1: Rapat Pleno Senat Universitas
        # Technician 1: Joko (IdUser 3)
        event_id = 1
        teknisi_id = 1
        user_id_tek = 3
        admin_id = 1
        
        # 1. Update SupportAcara Status to 'Ditugaskan'
        cursor.execute("UPDATE SupportAcara SET StatusAcara = 'Ditugaskan' WHERE IdAcara = ?", (event_id,))
        
        # 2. Insert Penugasan
        cursor.execute("""
            INSERT INTO Penugasan (IdAcara, IdTeknisi, IdUserAdmin, StatusPenugasan, Progress)
            VALUES (?, ?, ?, 'Ditugaskan', 0)
        """, (event_id, teknisi_id, admin_id))
        
        # 3. Update MappingTeknisi availability to 'Sibuk'
        cursor.execute("UPDATE MappingTeknisi SET StatusKetersediaan = 'Sibuk' WHERE IdTeknisi = ?", (teknisi_id,))
        
        # 4. Insert Notification
        created_at = datetime.now().isoformat()
        cursor.execute("""
            INSERT INTO Notifications (IdUser, Message, CreatedAt, Status)
            VALUES (?, ?, ?, 'Unread')
        """, (user_id_tek, "Penugasan baru untuk Event Rapat Pleno Senat Universitas.", created_at))
        
        conn.commit()
        print("SUCCESS: Simulation transaction executed successfully!")
        
    except Exception as e:
        conn.rollback()
        print("ERROR:", e)
    finally:
        conn.close()

if __name__ == '__main__':
    main()
